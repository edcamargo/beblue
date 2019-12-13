# Test Beblue

[![Build Status](https://travis-ci.com/edcamargo/beblue.svg?branch=master)](https://travis-ci.com/edcamargo/beblue)


**Procedimentos de execução:**

	1) Executar a API:
	http://localhost:62877/api/v1/Spotify/CargaAlbum

	2) Cadatrar um cliente pela API método Post: http://localhost:62877/api/v1/Clientes
	{
  		"nome": "Edwin Ramos Camargo",
		"id": "88b8a7d0-af56-410d-b7af-bf6ad1a050ec"
	}

	3) Consultar a Listagem de Disco Disponivel para venda pela API
	Ex: http://localhost:62877/api/v1/Discos/Genero/pop/Page/1/Length/10

	**Exemplo de Json para realizacao de venda**

	Json para gerar pedido com 1 item
	{
	  "ClienteId": "88b8a7d0-af56-410d-b7af-bf6ad1a050ec",
	  "PedidoItens": [
			  {
			  "DiscoId": "934af705-caf8-44b1-8e6b-a1ac472cbf19"
			  }
	  ]
	}

	Json para gerar pedido com mais de 1 item
	{
	  "ClienteId": "f199681f-1df1-4c8c-a5c0-2b0866157655",
	  "PedidoItens": [
			{
			  "DiscoId": "8131814f-c295-4bc4-bac0-777661cf54cf"
			},
			{
			  "DiscoId": "e4c44b3d-0ef7-4736-9cbb-d2ed51da572f"
			}
	  ]
	}