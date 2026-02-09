//using BCrypt.Net;

//public class PasswordHasher
//{
//    public string HashPassword(string password)
//    {
//        // ✅ Просто и работает
//        return BCrypt.HashPassword(password);
//    }

//    public bool VerifyPassword(string password, string hash)
//    {
//        // ✅ Проверка пароля
//        return BCrypt.Verify(password, hash);
//    }
//}

//// Использование:
//var hasher = new PasswordHasher();
//string hash = hasher.HashPassword("myPassword123");
//bool isValid = hasher.VerifyPassword("myPassword123", hash);