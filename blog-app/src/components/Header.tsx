import React from "react";
import "./Header.css";
import { Link } from "react-router-dom";
import { useLocation } from "react-router-dom";

const Header = () => {
  const path = useLocation();
  return (
    <header>
      <Link to="/" className="logo">
        BLOGS App
      </Link>
      <nav>
        <ul>
          {path.pathname !== "/" ? (
            <li>
              <Link to="/">Blogs</Link>
            </li>
          ) : null}
          {path.pathname !== "/authors" ? (
            <li>
              <Link to="/authors">Authors</Link>
            </li>
          ) : null}
          {path.pathname !== "/tags" ? (
            <li>
              <Link to="/tags">Tags</Link>
            </li>
          ) : null}
          {path.pathname !== "/addBlog" ? (
            <li>
              <Link to="/addBlog">Add Blog</Link>
            </li>
          ) : null}
        </ul>
      </nav>
    </header>
  );
};

export default Header;
