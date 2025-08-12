using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase {
    private readonly AppDbContext _appDbContext;
    
    public UserController(AppDbContext appDbContext) {
        _appDbContext = appDbContext;    
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers() {
        var users = await _appDbContext.Users.ToListAsync();
        return Ok(users);
    }
    
    /*
        Use Find for primary key lookups with EF caching.
        Use FirstOrDefault for any condition or more complex matching.
    */
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id) {
        var user = await _appDbContext.Users.FindAsync(id);

        if (user == null) return NotFound();
        
        return Ok(user);
    }
}