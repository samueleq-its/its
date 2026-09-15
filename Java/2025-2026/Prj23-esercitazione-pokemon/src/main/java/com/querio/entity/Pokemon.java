package com.querio.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(name = "pokemon")
public class Pokemon {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	private String name;
	@Column(name = "Type_1")
	private String type1;
	@Column(name = "Type_2")
	private String type2;
	private int total;
	private int hp;
	private int attack;
	private int defense;
	@Column(name = "Sp_Atk")
	private int spAtk;
	@Column(name = "Sp_Def")
	private int spDef;
	private int speed;
	private int generation;
	private String legendary;

}
