create or alter procedure PRC_CalculaInvestimento

@Valor as decimal(10,5),
@DataInicioInvestimento as DATE,
@DataTerminoInvestimento as DATE

AS

WITH TaxaDiaria AS (  
    SELECT   
        c.data as data_inicio,  
        c.valor as taxa_anual,  
        CASE   
            WHEN ROW_NUMBER() OVER (ORDER BY c.data) = 1 THEN 1
            ELSE ROUND(POWER(1 + (c.valor / 100), 1.0 / 252), 8) 
        END AS taxa_diaria
    FROM Cotacao c	 
	WHERE c.data between @DataInicioInvestimento and @DataTerminoInvestimento
),  
    
TaxaAcumulada AS (  
    SELECT   
        data_inicio,  
        taxa_anual,  
        taxa_diaria,    
        CASE   
            WHEN ROW_NUMBER() OVER (ORDER BY data_inicio) = 1 THEN 1
            ELSE EXP(SUM(LOG(taxa_diaria)) OVER (ORDER BY data_inicio))  
        END AS taxa_acumulada  
    FROM TaxaDiaria  
)  
    
SELECT   
    data_inicio,  
    taxa_anual,  
    taxa_diaria,  
    taxa_acumulada,  
    ROUND(@Valor * taxa_acumulada,2,8) AS valor_atualizado  
FROM TaxaAcumulada  
ORDER BY data_inicio;  
