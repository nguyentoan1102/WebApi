using System;
using System.Net.Http.Formatting;
using System.Reflection;

namespace PingYourPackage.API.Config
{
    public class SuppressedRequiredMemberSelector : IRequiredMemberSelector
    {
        public bool IsRequiredMember(MemberInfo member) => false;
    }
}