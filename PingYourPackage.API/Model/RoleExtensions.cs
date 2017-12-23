using PingYourPackage.API.Model.Dtos;
using PingYourPackage.Domain.Entities;
using System;

namespace PingYourPackage.API.Model
{

    internal static class RoleExtensions
    {

        internal static RoleDto ToRoleDto(this Role role)
        {

            if (role == null)
            {

                throw new ArgumentNullException(nameof(role));
            }

            return new RoleDto
            {
                Key = role.Key,
                Name = role.Name
            };
        }
    }
}