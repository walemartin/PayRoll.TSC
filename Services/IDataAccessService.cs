﻿using PayRoll.TSC.Models;
using System.Security.Claims;

namespace PayRoll.TSC.Services
{
	public interface IDataAccessService
	{
		Task<bool> GetMenuItemsAsync(ClaimsPrincipal ctx, string? ctrl, string? act);
		Task<List<NavigationMenuViewModel>> GetMenuItemsAsync(ClaimsPrincipal principal);
		Task<List<NavigationMenuViewModel>> GetPermissionsByRoleIdAsync(string? id);
		Task<bool> SetPermissionsByRoleIdAsync(string? id, IEnumerable<Guid> permissionIds);
	}
}
