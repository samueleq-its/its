package com.example.demo;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class Demo extends JFrame {

	private JLabel title;

	private JLabel nCategoria, nGiacenza, nNome, nPrezzo;
	private JTextField categoria, giacenza, nome, prezzo;

	private JTextArea textArea;
	private JButton button;
	private BorderLayout border;

	public Demo(String titolo) {
		this.title = new JLabel(titolo);
		//this.textArea = new JTextArea();
		this.button = new JButton("cliccami!");
		this.border = new BorderLayout();

		this.nNome = new JLabel("nome");
		this.nCategoria = new JLabel("categoria");
		this.nPrezzo = new JLabel("prezzo");
		this.nGiacenza = new JLabel("giacenza");

		this.nome = new JTextField();
		this.categoria = new JTextField();
		this.prezzo = new JTextField();
		this.giacenza = new JTextField();

		this.init();
	}

	public void init() {

		//button.addActionListener(e -> textArea.append("\tHello Window\n"));

		title.setBackground(Color.GRAY);
		title.setFont(new Font("Arial Bold", Font.ITALIC, 36));

		add(title, BorderLayout.NORTH);

		JPanel panel = new JPanel();
		panel.setLayout(new BoxLayout(panel, BoxLayout.Y_AXIS));

		panel.add(nNome, border.CENTER);
		panel.add(nome, border.CENTER);
		panel.add(nCategoria, border.CENTER);
		panel.add(categoria, border.CENTER);
		panel.add(nPrezzo, border.CENTER);
		panel.add(prezzo, border.CENTER);
		panel.add(nGiacenza, border.CENTER);
		panel.add(giacenza, border.CENTER);

		add(panel, border.CENTER);

		add(button, border.SOUTH);

		setTitle("Mia finestra");
		setSize(500, 400);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		setVisible(true);
	}
}
