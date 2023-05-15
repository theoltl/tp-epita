SRC = $(addprefix Tig/,	\
		CLI.cs Command.cs Hash.cs Index.cs Program.cs WorkingDir.cs)
BIN = sandbox/tig

all: ${BIN}

${BIN}: ${SRC}
	mkdir -p sandbox
	mcs ${SRC} -out:${BIN}
