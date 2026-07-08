package com.querio.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(name = "pokemon")
public class Pokemon {

	private int id;
	private String name;
	private String type1;
	private String type2;
	private int total;
	private int hp;
	private int attack;
	private int defense;
	private int spAtk;
	private int spDef;
	private int speed;
	private int generation;
	private String Legendary;

}
