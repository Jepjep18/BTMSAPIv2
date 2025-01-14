namespace BTMSAPI.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
    }

    public class CreateDepartmentDTO
    {
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
    }
}
