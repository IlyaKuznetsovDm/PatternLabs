using System;

class OpticalSystem
{
    private OpticalSystemState state;

    public OpticalSystem()
    {
        state = new InitialState(); 
    }

    public void SetState(OpticalSystemState state)
    {
        this.state = state;
    }

    public void PerformOperation()
    {
        state.PerformOperation(this);
    }
}

interface OpticalSystemState
{
    void PerformOperation(OpticalSystem system);
}

class InitialState : OpticalSystemState
{
    public void PerformOperation(OpticalSystem system)
    {
        Console.WriteLine("Расчет лучей...");
        system.SetState(new VisualizationState()); 
    }
}

class VisualizationState : OpticalSystemState
{
    public void PerformOperation(OpticalSystem system)
    {
        Console.WriteLine("Визуализация системы....");
        system.SetState(new AnotherState());
    }
}

class AnotherState : OpticalSystemState
{
    public void PerformOperation(OpticalSystem system)
    {
        Console.WriteLine("Выполнение другой операции.....");
    }
}

class Program
{
    static void Main()
    {
        OpticalSystem opticalSystem = new OpticalSystem();

        opticalSystem.PerformOperation(); 
        opticalSystem.PerformOperation(); 
        opticalSystem.PerformOperation(); 
    }
}