package com.querio.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entity.Pokemon;

public interface PokemonRepo extends JpaRepository<Pokemon, Integer> {

}
