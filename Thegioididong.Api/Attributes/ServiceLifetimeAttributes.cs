namespace Thegioididong.Api.Attributes
{
    /// <summary>
    /// Specifies that the class should be registered as a scoped service.
    /// </summary>
    public class ScopedRegistrationAttribute : Attribute { }

    /// <summary>
    /// Specifies that the class should be registered as a singleton service.
    /// </summary>
    public class SingletonRegistrationAttribute : Attribute { }

    /// <summary>
    /// Specifies that the class should be registered as a transient service.
    /// </summary>
    public class TransientRegistrationAttribute : Attribute { }
}
