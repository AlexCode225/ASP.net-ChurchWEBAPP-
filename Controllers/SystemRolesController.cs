using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Stock_system.Controllers
{
  
    public class SystemRolesController : Controller
    { 
        
        private readonly RoleManager<IdentityRole> _roleManager;

        //contructor for the identity
        public SystemRolesController(RoleManager<IdentityRole> roleManager)
        {
            ///instance the role manager 
           _roleManager = roleManager;
        }
        // who can see what are the admins
        [Authorize(Roles = " Admin")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            //return the role i have created 
            return View(roles);
        }


      

     //   // Only admin can create  role
     [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


       
       // // Only admin can create  role
       [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //make sure it does not duplicate roles 
            if (!_roleManager.RoleExistsAsync (model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new   IdentityRole(model.Name) ).GetAwaiter().GetResult();
            }

            return RedirectToAction("Index");
        }





    }
}
