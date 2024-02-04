namespace Utilities.Container.Option
{
    /// <summary>
    /// Thành viên là không được đọc và ghi vào container
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SkipContainerAttribute : Attribute
    {
    }
}
