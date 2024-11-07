-- 1 - Buscar o nome e ano dos filmes
SELECT nome, ano
FROM filmes;

-- 2 - Buscar o nome e ano dos filmes, ordenados por ordem crescente pelo ano
SELECT nome, ano
FROM filmes
ORDER BY ano ASC;

-- 3 - Buscar pelo filme "De Volta para o Futuro", trazendo o nome, ano e a duração
SELECT nome, ano, duracao
FROM filmes
WHERE nome = 'De Volta para o Futuro';

-- 4 - Buscar os filmes lançados em 1997
SELECT nome, ano
FROM filmes
WHERE ano = 1997;

-- 5 - Buscar os filmes lançados APÓS o ano 2000
SELECT nome, ano
FROM filmes
WHERE ano > 2000;

-- 6 - Buscar os filmes com duração maior que 100 e menor que 150, ordenando pela duração em ordem crescente
SELECT nome, duracao
FROM filmes
WHERE duracao > 100 AND duracao < 150
ORDER BY duracao ASC;

-- 7 - Buscar a quantidade de filmes lançados no ano, agrupando por ano, ordenando pela duração em ordem decrescente
SELECT ano, COUNT(*) AS quantidade_filmes
FROM filmes
GROUP BY ano
ORDER BY duracao DESC;

-- 8 - Buscar os Atores do gênero masculino, retornando o PrimeiroNome e UltimoNome
SELECT PrimeiroNome, UltimoNome
FROM atores
WHERE genero = 'Masculino';

-- 9 - Buscar os Atores do gênero feminino, retornando o PrimeiroNome, UltimoNome, e ordenando pelo PrimeiroNome
SELECT PrimeiroNome, UltimoNome
FROM atores
WHERE genero = 'Feminino'
ORDER BY PrimeiroNome ASC;

-- 10 - Buscar o nome do filme e o gênero
SELECT f.nome, g.genero
FROM filmes f
JOIN generos g ON f.genero_id = g.id;

-- 11 - Buscar o nome do filme e o gênero do tipo "Mistério"
SELECT f.nome, g.genero
FROM filmes f
JOIN generos g ON f.genero_id = g.id
WHERE g.genero = 'Mistério';

-- 12 - Buscar o nome do filme e os atores, trazendo o PrimeiroNome, UltimoNome e seu Papel
SELECT f.nome AS nome_filme, a.PrimeiroNome, a.UltimoNome, pa.papel
FROM filmes f
JOIN papéis pa ON f.id = pa.filme_id
JOIN atores a ON pa.ator_id = a.id;
