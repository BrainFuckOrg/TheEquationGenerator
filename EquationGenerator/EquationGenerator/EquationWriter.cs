namespace EquationGenerator;

public static class EquationWriter
    {
        public static String GenerateEquationWithKoefs(Int32[] coeffs)
        {
            if (coeffs.Length < 2)
            {
                throw new Exception("Too few koefs");
            }

            String equation = "";
            UInt16 extant = (UInt16)(coeffs.Length - 1);
            Int16 coeffNum = 0;
            Boolean withSpaces = false;

            do
            {
                equation += XWithCoeff(coeffs[coeffNum++], extant, ref withSpaces);
            } while (extant-- > 0);
            {
                
            }
            equation += " = 0";
            
            return equation;
        }

        private static String XWithCoeff(Int32 coeff, UInt16 extant, ref Boolean withSpaces)
        {
            String equation = "";
            if (coeff == 0)
            {
                return "";
            }

            equation += RightStringNumber(coeff, ref withSpaces);
            
            if (extant == 0)
            {
                equation += Math.Abs(coeff);
                return equation;
            }
            
            equation += Math.Abs(coeff) == 1 ? "" : Math.Abs(coeff);
            equation +=  "x";
            equation += extant == 1 ? "" : SupNumber(extant);
            return equation;
        }

        private static String RightStringNumber(Int32 coeff, ref Boolean withSpaces)
        {
            String equation = "";

            if (withSpaces)
            {
                equation += coeff > 0 ? " + " : " - ";
            }
            else
            {
                withSpaces = true;
                equation += coeff > 0 ? "": "-";
            }
            return equation;
            
        }
        private static String SupNumber(UInt16 number)
        {
            Char[] supNumbers = new[] { '\x2070', '\xB9', '\xB2', '\xB3', '\x2074','\x2075','\x2076', '\x2077', '\x2078', '\x2079'};
            
            String degree = "";
            foreach (var numberPart in number.ToString())
            {
                //Console.WriteLine((Int16)numberPart);
                degree += supNumbers[numberPart - '0'];
            }

            return degree;
        }
    }
    