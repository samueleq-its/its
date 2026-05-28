package com.querio.repos;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.querio.entities.Automobile;

@Repository
public interface AutomobiliRepo extends JpaRepository<Automobile, Integer>{

}
