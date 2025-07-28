using TTT.Roles.Roles;

namespace TTT.Public.Mod.Roles;

public interface IRoleFactory {
  BaseRole Get(RoleType type);
}