import { useEffect } from "react";
import { fetchBlogs, useAppDispatch, useAppSelector } from "../state";
import "./cards.css";
import { Blogpost } from "../state/reducers/blogsReducer";
import { List } from "immutable";

const BlogPostGrid = () => {
  const state = useAppSelector((state) => state.blogs);
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchBlogs());
  }, [dispatch]);

  const loading = state.get("loading");
  const error = state.get("error");
  const blogposts = state.get("blogposts", List<Blogpost>());

  if (error) return <div>ERROR! {error?.message}</div>;
  if (loading) return <div>loading</div>;
  return blogposts.size < 1 ? (
    <div>No Blogs yet</div>
  ) : (
    <>
      <h2>Blogs</h2>
      <div className="card-container">
        {blogposts.map((blog: Blogpost) => (
          <div className="card" key={blog.id}>
            <h2>{blog.title}</h2>
            <p>{blog.textBody}</p>
            {blog.tags && blog.tags.length > 0 ? <h4>Tags:</h4> : null}
            {blog.tags?.map((tag) => (
              <span key={tag.id}> {tag.name}</span>
            ))}
          </div>
        ))}
      </div>
    </>
  );
};

export default BlogPostGrid;
