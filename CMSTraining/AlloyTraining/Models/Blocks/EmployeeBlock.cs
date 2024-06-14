using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(
        Description = "Use this to store information about an employee.",
        DisplayName = "Employee",
        GroupName = SiteGroupNames.Specialized,
        Order = 10)]
    [SiteBlockIcon]
    public class EmployeeBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Name = "First name",
            Order = 10)]
        public virtual string FirstName { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Name = "Last name",
            Order = 20)]
        public virtual string LastName { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Name = "Hire date",
            Order = 30)]
        public virtual DateTime? HireDate { get; set; }
    }
}
