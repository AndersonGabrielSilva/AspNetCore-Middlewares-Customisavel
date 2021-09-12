
## Startup Filters
	- Permite configurar middlewares antes de todos aqueles adicionados pela aplicação
	- Requer apenas a injeção no container de serviços
	- Execulta na ordem de injeção, antes do Startup.Configure
	- Permite adicionar serviços de middlewares, antes mesmo que todos os middlewares da aplicação seja adicionado.
	este servico é adicionado no "Configure services".
	- Destá forma é possivel Modularizar a injeção dos middlewares