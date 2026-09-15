package model;

public class Prodotto {

    private int id;
    private String nome;
    private String categoria;
    private double prezzo;
    private int giacenza;

    /**
     * Costruttore del Prodotto senza Argomenti
     */
    public Prodotto() {}

    /**
     * Costruttore del Prodotto 3 args
     * @param nome Inserire il nome del prodotto
     * @param prezzo Inserire il prezzo con il separatore '.'
     * @param giacenza Inserire la giacenza...
     */
    public Prodotto(String nome, double prezzo, int giacenza) {
        this.nome = nome;
        this.prezzo = prezzo;
        this.giacenza = giacenza;
        this.id = 0;
        this.categoria = "Articoli Vari";
    }

    public Prodotto(int giacenza, double prezzo, String categoria, String nome, int id) {
        this.giacenza = giacenza;
        this.prezzo = prezzo;
        this.categoria = categoria;
        this.nome = nome;
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getCategoria() {
        return categoria;
    }

    public void setCategoria(String categoria) {
        this.categoria = categoria;
    }

    public double getPrezzo() {
        return prezzo;
    }

    public void setPrezzo(double prezzo) {
        this.prezzo = prezzo;
    }

    public int getGiacenza() {
        return giacenza;
    }

    public void setGiacenza(int giacenza) {
        this.giacenza = giacenza;
    }

    @Override
    public String toString() {
        return "Prodotto{" +
                "id=" + id +
                ", nome='" + nome + '\'' +
                ", categoria='" + categoria + '\'' +
                ", prezzo=" + prezzo +
                ", giacenza=" + giacenza +
                '}';
    }
}
