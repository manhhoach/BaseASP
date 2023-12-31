namespace BaseASP.Model.Common
{
    public interface IEntityBase
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }

        string? CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string? UpdatedBy { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DeletedDate { get; set; }
    }
}
