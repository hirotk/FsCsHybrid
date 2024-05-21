(* This is the C# code shown previously.
// C#/F# hybrid way
// You can easily convert this static class into a F# module later
public static class CameraModule
{
    // Greatest Common Divisor (GCD)
    // int->int -> int
    public static int Gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return Gcd(b, a % b);
    }

    // int->int -> (int,int)
    public static (int,int) GetBaseRatio(int width, int height)
    {
        int gcd = Gcd(width, height);
        return (width / gcd, height / gcd);
    }
}
*)
module CameraModule

// Greatest Common Divisor (GCD)
let rec gcd a b =
    match b with
    | 0 -> a
    | _ -> gcd b (a % b)

// camelCase is the convention in F#
let getBaseRatio width height =
    let div = gcd width height
    width / div, height / div
