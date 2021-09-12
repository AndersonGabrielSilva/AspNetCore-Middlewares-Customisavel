
#Anotaçoes 

##O que é um Pipeline ?
	- A segmentação de instruções é uma técnica de hardware que permite que a CPU realize a busca de uma 
	ou mais instruções além da próxima a ser executada.
	- É basicamente a ordem que todos os Middleware, irão processar a solicitação realizada.

##O que é um Middleware?
	- Software montado no popeline de um aplicativo ASP.NET Core para manipular solicitaçoes e respostas.
	- Cada Middleware escolhe se deseja passar a solicitação para o próximo middleware no pipeline.
	- Cada Middleware pode execultar seu trabalho antes ou depois do proximo componente do pipeline.
	- É possivel fazer o que eu quiser dentro de um middleware:
		- Modificar as informaçoes da requisição.
		- Modificar as informaçoes do corpo da requisição.
		- Modificar as informaçoes do cabecalho da requisição.
		- Modificar as informaçoes da resposta da requisição.
		- Ou mesmo modificar a rota em que estes middleware irão funcionar.
	
##Fluxo da Requisição
	- Toda nova requisição, passa por todos os Middleware, e cada middleware pode escolher ou não passar 
	está requisição para frente funciona basicamente como um filtro. Mais pode conter varias aplicaçoes 
	dependendo da logica do negocio.
	- Após acabar de passar por todos os Middleware inscritos no Pipeline a requisição volta passando por
	todos os Middleware novamente.
	Ex: 
		*Inicio da requisição
		Middleware 1 -> Middleware 2 -> Middleware 3 -> Middleware 4 
		*Retorna a requisição
		Middleware 1 <- Middleware 2 <- Middleware 3 <- Middleware 4 
		
##Pipeline de Requisição do Asp.Net Core 
	- As requisições passam por todos os Middlewares, alguns deles podento ser mapeados a padroes de URL 
	específicos.
	- Os Middlewares são execultados do primeiro ao ultimo e depois até o primeiro novamente.
	- Middlewares podem interrimper (short-circuit) as requisições.
		
		