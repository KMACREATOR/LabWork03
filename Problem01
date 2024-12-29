using System;

public struct Vector
{
    public float x;
    public float y;
    public float z;

    // Конструктор
    public Vector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Оператор сложения векторов
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    // Оператор умножения векторов (скалярное произведение)
    public static float operator *(Vector a, Vector b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    // Оператор умножения вектора на число
    public static Vector operator *(Vector v, float scalar)
    {
        return new Vector(v.x * scalar, v.y * scalar, v.z * scalar);
    }

    // Оператор равенства по длине
    public static bool operator ==(Vector a, Vector b)
    {
        return a.Length() == b.Length();
    }

    // Оператор неравенства по длине
    public static bool operator !=(Vector a, Vector b)
    {
        return a.Length() != b.Length();
    }

    // Метод для вычисления длины вектора
    public float Length()
    {
        return (float)Math.Sqrt(x * x + y * y + z * z);
    }

    // Переопределяем Equals и GetHashCode
    public override bool Equals(object obj)
    {
        if (obj is Vector)
        {
            Vector v = (Vector)obj;
            return this.Length() == v.Length();
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Length().GetHashCode();
    }

    // Для удобства вывода вектора
    public override string ToString()
    {
        return $"Vector({x}, {y}, {z})";
    }
}

// Пример использования
public class Program
{
    public static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);

        Vector sum = v1 + v2;
        float dotProduct = v1 * v2;
        Vector scaled = v1 * 2;

        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Скалярное произведение: {dotProduct}");
        Console.WriteLine($"Умноженный вектор: {scaled}");
        Console.WriteLine($"Два вектора равны по длине? {v1 == v2}");
    }
}
