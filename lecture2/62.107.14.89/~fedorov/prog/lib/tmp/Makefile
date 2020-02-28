cmath.dll: ../complex/complex.cs ../complex/cmath.cs
	mcs -target:library -out:$@ $^
	cp ../complex/cmath.dll .

.PHONEY:clean
clean:
	$(RM) cmath.dll
