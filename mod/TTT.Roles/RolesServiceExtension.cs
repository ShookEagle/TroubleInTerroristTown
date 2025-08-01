using Microsoft.Extensions.DependencyInjection;
using TTT.Public.Extensions;
using TTT.Public.Mod.Roles;
using TTT.Roles.Listeners;

namespace TTT.Roles;

public static class RolesServiceExtension {
  public static void AddTTTRoles(this IServiceCollection serviceCollection) {
    serviceCollection.AddPluginBehavior<IRoleFactory, RoleFactory>();
    serviceCollection.AddPluginBehavior<RoleAssignmentListener>();
  }
}