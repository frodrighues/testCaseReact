using System.ComponentModel.DataAnnotations;

namespace testCaseReact.DTO
{
    public class BistroUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int PermissionRoleId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Surname { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        //public BistroPermission PermissionRole { get; set; }
        //public BistroRole Role { get; set; }
    }
}
