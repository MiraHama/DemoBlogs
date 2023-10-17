import { useAppDispatch, useAppSelector } from "../state";
import { useEffect } from "react";
import { fetchAuthors } from "../state";
import "./cards.css";
import { Author } from "../state/reducers/authorsReducer";
import { List } from "immutable";

export const AuthorGrid = () => {
  const state = useAppSelector((state) => state.authors);
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchAuthors());
  }, [dispatch]);

  const loading = state.get("loading");
  const error = state.get("error");
  const authors = state.get("authors", List<Author>());

  if (error) return <div>ERROR! {error?.message}</div>;
  if (loading) return <div>loading</div>;
  return authors.size < 1 ? (
    <div>No Authors Yet</div>
  ) : (
    <>
      <h2>Authors</h2>
      <div className="card-container">
        {authors?.map((author: Author) => (
          <div className="card" key={author.id}>
            <h2>{author.name}</h2>
            {author.posts && author.posts.length > 0 ? <h4>Blogs:</h4> : null}
            {author.posts?.map((post) => (
              <span key={post.id}>{post.title} </span>
            ))}
          </div>
        ))}
      </div>
    </>
  );
};
