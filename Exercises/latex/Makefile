all:matlib.dll exercise.pdf out.txt plot.svg

exercise.pdf: exercise.tex
	pdflatex $<
	pdflatex $<

out.txt: sin.exe Makefile
	mono $< 1> $@ 2>log

plot.svg: plot.gpi out.txt
	gnuplot $<

LIBDIR = ../matlib
SRC := $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/ode/ode.cs
matlib.dll: sin.cs $(SRC)
	mcs $^ -target:library -out:$@

sin.exe: sin.cs matlib.dll
	mcs -reference:matlib.dll $<

clean:
	$(RM) *.log *.aux *.pdf *.dvi

test:
	echo $(SRC)