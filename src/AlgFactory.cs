using System;
using System.Security.Cryptography;

public record AlgFactory(Func<SymmetricAlgorithm> Alg, string Display)
{
    public override string ToString() => Display;

    public void Deconstruct(out Func<SymmetricAlgorithm> alg, out string display)
    {
        alg = Alg;
        display = Display;
    }
}