source = Bot.cs Game.cs Generation.cs Layer.cs NeuralNetwork.cs Neurone.cs Node.cs Snake.cs

csharp_flags = -sdk:2 -out:$(EXECUTABLE)

CSC = mcs

EXECUTABLE = Snake.exe

all: $(EXECUTABLE) 

$(EXECUTABLE): $(source) Program.cs
	@ mcs $^ $(csharp_flags)

clean:
	@ echo cleaning ...
	@ rm -f $(EXECUTABLE)


