using System;

namespace ClassLibrary.Authorization
{
    // Centralized permission names used by server and clients.
    // Use string constants to allow dynamic permission names like "users.create".
    public static class Permissions
    {
        public const string UsersCreate = "users.create";
        public const string UsersRead = "users.read";
        public const string UsersDelete = "users.delete";

        public const string CharacterCreate = "character.create";
        public const string CharacterRead = "character.read";
        public const string CharacterDelete = "character.delete";

        // Add more permission names here as needed
    }
}
