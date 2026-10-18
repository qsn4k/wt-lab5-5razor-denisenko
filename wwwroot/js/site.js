(() => {
    const currentPath = window.location.pathname.toLowerCase();
    document.querySelectorAll('.navbar-nav .nav-link').forEach(link => {
        const target = new URL(link.href, window.location.origin).pathname.toLowerCase();
        if (target === currentPath || (target === '/players/index' && currentPath === '/players')) {
            link.classList.add('active');
            link.setAttribute('aria-current', 'page');
        }
    });
})();
