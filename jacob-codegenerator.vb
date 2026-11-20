public class JacobNr
    private function PullRingWithSealand
        dim 3mm(19) as int = {
            12,15,16,,17,20,22,25,30,35,40,45,50,6,32
        } 
        dim 2mm(19) as int = {
            08,10,12,14,15,16,17,20,22,25,28,30,31,35,40,45,50,56,63
        } 
        dim 1mm(17) as int = {
            08,10,12,14,15,16,17,20,22,25,28,30,31,35,40,45,50
        } 
        for each 1mm as Integer
            ''11mm2381 so a jacob number is 11082381
        next
        for each 2mm as Integer
            ''11mm2382 so a jacob number is 11082382
        next
        for each 3mm as Integer
            ''11mm2383 so a jacob number is 11122383
        next
    end function

    private function U-shapedSeals1mm
        dim mm as int ={
            06,08,10,12,14,15,16,17,20,22,25,28,30,31,35,40,45,50,56,63
        }

        for each mm as Integer{
            ''for NBR last 5 69517
            '' 10mm69517

            ''for sillicone beige 795109
            ''10mm795109

            ''sillicone blue 7951091
            ''10mm7951091

            ''EPDM black 895159
            ''10mm895159

            ''Vilton 99519
            ''10mm99519
        }
    end function
    private function U-shapedSeals2mm
        dim mm as int ={
            06,08,10,12,14,15,16,17,20,22,25,28,30,31,35,40,45,50,56,63
        }

        for each mm as Integer{
            ''for NBR last 5 69527
            '' 10mm69527

            ''for sillicone beige 795209
            ''10mm795209

            ''sillicone blue 7952091
            ''10mm7952091

            ''EPDM black 895259
            ''10mm895259

            ''Vilton 93869
            ''10mm93869
        }
    end function

end class