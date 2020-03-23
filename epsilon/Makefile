# CSFLAGS = -warn:3

# out.txt : main.exe
# 	mono main.exe > out.txt

# main.exe : main.cs cmath.dll
# 	mcs $(CSFLAGS) -reference:cmath.dll -out:main.exe main.cs

# CDIR=../complex
# cmath.dll: $(CDIR)/cmath.cs $(CDIR)/complex.cs
# 	mcs $(CFLAGS) -target:library -out:$@ $^  # $^ = all prerequisites
# cmath.dll : cmath.cs complex.cs
# 	mcs -target:library -out:cmath.dll cmath.cs complex.cs

# .PHONEY:clean
# clean:
# 	rm --force out* *.dll *.exe

CSFLAGS = -optimize+ - platform:amdx86
.PHONEY:all
all: out.txt
	cat out.txt

out.txt : main.exe 
	mono main.exe > out.txt
main.exe : main.cs cmath.dll
	mcs $(CFLAGS) -reference:cmath.dll -out:main.exe main.cs

cmath.dll: ../complex/cmath.cs ../complex/complex.cs
	mcs $^ -target:library -out:$@ 
	cp ../complex/cmath.dll .
clean: 
	rm --force out.txt main.exe