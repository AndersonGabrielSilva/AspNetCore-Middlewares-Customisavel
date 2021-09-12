
## Como é que eu faço para criar um Middleware ?
	- Basta apenas implementar os metodos da IApplicationBuilder
	
##Interface - "IApplicationBuilder"
	- Metodos
		- IApplicationBuilder.Use
			-: Adiciona um delegade no pipeline.
			
		- IApplicationBuilder.Map
			-: Ramifica o pipeline com base na URL.
			
		- IApplicationBuilder.MapWhen
			-: Ramifica o pipeline com base em uma condição.
			
		- IApplicationBuilder.Run
			-: Execulta e finaliza o pipeline
			

#Detalhes dos metodos

## IApplicationBuilder.Use	
	- Adiciona um delegade no pipeline.
	- Delegate recebe o contexto da requisição e o delegate para o priximo middleware.
	- Permite short-circuit, ou seja encerrar o pipeline, ao não execultar o próximo delegate.
	- Pode execultar o p´roximo delegate, bem como execultar código após o mesmo.
	
## IApplicationBuilder.Map / .MapWhen
	- *Map* adiciona um delegade no pipeline que é executado apenas se a URL iniciar com o padrão 
	especifico.
		- Remove o padrão do Path, o passando para o BasePath, permitindo mapeamentos alinhados.
	- *MapWhen* adiciona um delegate no pipeline que é execultado apenas se o predicate com as condiçoes
	necessarias for satisfeito.
	-Ambos ramificam o pipeline adicionando seus proprios delegates.

## IApplicationBuilder.Run
	- Finaliza o pipeline, sendo o último a execultar.
	- Pode ser o único delegade do pipeline.
	- Recebe apenas o contexto da requisição.
	