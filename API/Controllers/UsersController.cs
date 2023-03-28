using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    private readonly IPhotoService _photoService;

    public UsersController(IMapper mapper, IUserRepository userRepository, IPhotoService photoService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _photoService = photoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAsync();

        return Ok(users);
    }

    [HttpGet("{username}")]

    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberAsync(username);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
    {
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userRepository.GetUserByUsernameAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        _mapper.Map(memberUpdateDto, user);

        return await _userRepository.SaveAllAsync() ? NoContent() : BadRequest("Failed to update user");
    }

    [HttpPost("add-photo")]
    public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
    {
        var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

        if (user == null)
        {
            return NotFound();
        }

        var result = await _photoService.AddPhotoAsync(file);

        if (result.Error != null)
        {
            return BadRequest(result.Error.Message);
        }

        var photo = new Photo
        {
            Url = result.SecureUrl.AbsoluteUri,
            PublicId = result.PublicId
        };

        if (user.Photos.Count == 0)
        {
            photo.IsMain = true;
        }

        user.Photos.Add(photo);

        return await _userRepository.SaveAllAsync()
            ? (ActionResult<PhotoDto>)CreatedAtAction(
                nameof(GetUser),
                new { username = user.UserName },
                _mapper.Map<PhotoDto>(photo))
            : (ActionResult<PhotoDto>)BadRequest("Problem adding photo");
    }
}
