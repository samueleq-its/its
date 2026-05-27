<nav>
  <ul>
    <li><strong><?= TITOLO ?></strong></li>
  </ul>
  <ul>
    <li><a href="?pagina=about">about</a></li>
    <li><a href="?pagina=contact">contact</a></li>
    
    <li><a href="?pagina=products">products</a></li>
    
    <?php if ($_SESSION['logged_in'] ?? false): ?>
    <li><a href="?pagina=logout"><?= $_SESSION['username'] ?> logout</a></li>
    <?php else: ?> 
    <li><a href="?pagina=home">login</a></li>
    <?php endif; ?>

  </ul>
</nav>