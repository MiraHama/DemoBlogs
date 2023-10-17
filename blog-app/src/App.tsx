import React from "react";
import "./App.css";
import { AuthorGrid } from "./components/AuthorGrid";
import BlogPostGrid from "./components/BlogPostGrid";
import Layout from "./components/Layout";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import BlogForm from "./components/BlogForm";
import { TagGrid } from "./components/TagGrid";
function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<BlogPostGrid />} />
          <Route path="/authors" element={<AuthorGrid />} />
          <Route path="/addblog" element={<BlogForm />} />
          <Route path="/tags" element={<TagGrid />} />
          <Route path="*" element={<BlogPostGrid />} />
        </Routes>
      </Layout>
    </Router>
  );
}

export default App;
