using System.ComponentModel.DataAnnotations;

namespace manage_staff.Models;

public partial class Staff
{
    public byte? Status { get; set; } = 0;

    public long? CreatedDate { get; set; }

    public long? LastModifiedDate { get; set; }

    public Guid Id { get; set; }

    [Required(ErrorMessage = "Không được bỏ trống")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@fe\.edu\.vn$|^[^\s]*$|^[^ạáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ]*$", ErrorMessage = "Email FE phải kết thúc với đuôi @fe.edu.vn và không chứa khoảng trắng")]
    public string? AccountFe { get; set; }

    [Required(ErrorMessage = "Không được bỏ trống")]
    [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@fpt\.edu\.vn$|^[^\s]*$|^[^ạáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ]*$", ErrorMessage = "Email FPT phải kết thúc với đuôi @fpt.edu.vn và không chứa khoảng trắng")]
    public string? AccountFpt { get; set; }

    [Required(ErrorMessage = "Không được bỏ trống")]
    [StringLength(100, ErrorMessage = "Tên không được dài quá 100 ký tự")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Không được bỏ trống")]
    [StringLength(15, ErrorMessage = "Mã không được dài quá 15 ký tự")]
    public string? StaffCode { get; set; }

    public virtual ICollection<DepartmentFacility> DepartmentFacilities { get; set; } = new List<DepartmentFacility>();

    public virtual ICollection<StaffMajorFacility> StaffMajorFacilities { get; set; } = new List<StaffMajorFacility>();
}