namespace Utilities.Container.Option
{
    /// <summary>
    /// Class được đọc và ghi vào một container
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ClassContainerAttribute : Attribute
    {
    }

    /// <summary>
    /// Thành viên là không được đọc và ghi vào container
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SkipContainerAttribute : Attribute
    {
    }
}
