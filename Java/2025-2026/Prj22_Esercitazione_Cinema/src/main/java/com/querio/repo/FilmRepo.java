package com.querio.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entity.Film;

public interface FilmRepo extends JpaRepository<Film,Integer> {

}
