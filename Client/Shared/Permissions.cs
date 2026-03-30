using System;

namespace Client.Shared
{
    // Client-side mirror of server permission names
    public static class Permissions
    {
        public const string UsersCreate = "users.create";
        public const string UsersRead = "users.read";
        public const string UsersDelete = "users.delete";

        public const string CharacterCreate = "character.create";
        public const string CharacterRead = "character.read";
        public const string CharacterDelete = "character.delete";
    }
}
