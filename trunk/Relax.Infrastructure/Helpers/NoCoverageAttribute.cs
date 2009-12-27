using System;

namespace Relax.Infrastructure.Helpers
{
    [AttributeUsage(AttributeTargets.All)]
    public class NoCoverageAttribute : Attribute
    {
    }
}