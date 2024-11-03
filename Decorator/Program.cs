using System;

// Интерфейс пиццы
public interface IPizza
{
    string GetDescription();
    double GetCost();
}

// Конкретные виды пиццы
public class ItalianPizza : IPizza
{
    public string GetDescription()
    {
        return "Italian Pizza";
    }

    public double GetCost()
    {
        return 8.0;
    }
}

public class BulgarianPizza : IPizza
{
    public string GetDescription()
    {
        return "Bulgarian Pizza";
    }

    public double GetCost()
    {
        return 7.0;
    }
}

// Абстрактный декоратор для добавок
public abstract class PizzaDecorator : IPizza
{
    protected IPizza _pizza;

    public PizzaDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }

    public virtual string GetDescription()
    {
        return _pizza.GetDescription();
    }

    public virtual double GetCost()
    {
        return _pizza.GetCost();
    }
}

// Декоратор для добавки "Помидоры"
public class TomatoDecorator : PizzaDecorator
{
    public TomatoDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", Tomato";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 1.0; // Дополнительная стоимость за помидоры
    }
}

// Декоратор для добавки "Сыр"
public class CheeseDecorator : PizzaDecorator
{
    public CheeseDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", Cheese";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 1.5; // Дополнительная стоимость за сыр
    }
}

// Пример использования
public class Program
{
    public static void Main(string[] args)
    {
        // Заказ итальянской пиццы с помидорами и сыром
        IPizza pizza = new ItalianPizza();
        pizza = new TomatoDecorator(pizza);
        pizza = new CheeseDecorator(pizza);

        Console.WriteLine($"Описание: {pizza.GetDescription()}");
        Console.WriteLine($"Стоимость: {pizza.GetCost()}");

        // Заказ болгарской пиццы с сыром
        IPizza pizza2 = new BulgarianPizza();
        pizza2 = new CheeseDecorator(pizza2);

        Console.WriteLine($"Описание: {pizza2.GetDescription()}");
        Console.WriteLine($"Стоимость: {pizza2.GetCost()}");
    }
}
