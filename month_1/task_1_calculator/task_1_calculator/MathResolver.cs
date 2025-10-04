namespace task_1_calculator;

public class MathResolver
{
    private readonly List<float> _numbers = [];
    private readonly List<string> _operators = [];
    private float _result = 0;

    private static readonly string[] ValidOperators = ["+", "-", "*", "/"];

    public void AddNumber(float number)
    {
        _numbers.Add(number);
    }

    public void AddOperator(string op)
    {
        if (IsOperatorValid(op))
        {
            _operators.Add(op);
        }
    }

    public float Calculate()
    {
        if (_numbers.Count < 2)
            throw new InvalidOperationException("Недостаточно чисел для вычисления");
        
        if (_operators.Count == 0)
            throw new InvalidOperationException("Не указан оператор");

        _result = _numbers[0];
        
        for (var i = 1; i < _numbers.Count; i++)
        {
            var currentOperator = _operators.Count >= i ? _operators[i - 1] : _operators[^1];
            
            switch (currentOperator)
            {
                case "+":
                    _result += _numbers[i];
                    break;
                case "-":
                    _result -= _numbers[i];
                    break;
                case "*":
                    _result *= _numbers[i];
                    break;
                case "/":
                    if (_numbers[i] == 0)
                        throw new DivideByZeroException("Деление на ноль невозможно");
                    _result /= _numbers[i];
                    break;
            }
        }
        
        return _result;
    }

    public static bool IsOperatorValid(string op)
    {
        return ValidOperators.Contains(op);
    }
    
    public void Clear()
    {
        _numbers.Clear();
        _operators.Clear();
        _result = 0;
    }
}