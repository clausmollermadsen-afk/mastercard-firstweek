namespace Master.Firstweek.Client;

/// <summary>
/// Represents a discriminated union of two possible types. An instance of <see cref="Either{TL,TR}"/> holds a value of either type <typeparamref name="TL"/> (left) or <typeparamref name="TR"/> (right).
/// </summary>
/// <typeparam name="TL">The type of the left value.</typeparam>
/// <typeparam name="TR">The type of the right value.</typeparam>
public class Either<TL, TR>
{
    private readonly TL? _left;
    private readonly TR? _right;
    private readonly bool _isLeft;

    /// <summary>
    /// Initializes a new instance of the <see cref="Either{TL,TR}"/> class with a left value.
    /// </summary>
    /// <param name="left">The left value.</param>
    public Either(TL left)
    {
        _left = left;
        _isLeft = true;
        _right = default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Either{TL,TR}"/> class with a right value.
    /// </summary>
    /// <param name="right">The right value.</param>
    public Either(TR right)
    {
        _right = right;
        _isLeft = false;
        _left = default;
    }
    
    /// <summary>
    /// Applies the appropriate function to the value, depending on whether it is left or right.
    /// </summary>
    /// <typeparam name="T">The return type of the functions.</typeparam>
    /// <param name="leftFunc">The function to apply if the value is left.</param>
    /// <param name="rightFunc">The function to apply if the value is right.</param>
    /// <returns>The result of the applied function.</returns>
    public T Match<T>(Func<TL, T> leftFunc, Func<TR, T> rightFunc)
        => _isLeft ? leftFunc(_left!) : rightFunc(_right!);
    
    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="TL"/> to an <see cref="Either{TL,TR}"/>.
    /// </summary>
    /// <param name="left">The left value.</param>
    public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="TR"/> to an <see cref="Either{TL,TR}"/>.
    /// </summary>
    /// <param name="right">The right value.</param>
    public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);
}