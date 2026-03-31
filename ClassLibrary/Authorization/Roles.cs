using System;

namespace ClassLibrary.Authorization
{
    // our roles are here
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
