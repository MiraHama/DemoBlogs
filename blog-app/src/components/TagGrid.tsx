import { useAppDispatch, useAppSelector } from "../state";
import { useEffect } from "react";
import "./cards.css";
import { List } from "immutable";
import { fetchTags } from "../state/actions/tagActions";
import { Tag } from "../state/reducers/tagsReducer";

export const TagGrid = () => {
  const state = useAppSelector((state) => state.tags);
  const dispatch = useAppDispatch();
  useEffect(() => {
    dispatch(fetchTags());
  }, [dispatch]);

  const loading = state.get("loading");
  const error = state.get("error");
  const blogTags = state.get("tags", List<Tag>());

  if (error) return <div>ERROR! {error?.message}</div>;
  if (loading) return <div>loading</div>;
  return blogTags.size < 1 ? (
    <div>No Tags Yet</div>
  ) : (
    <>
      <h2>Tags</h2>
      <div className="tag-container">
        {blogTags?.map((tag: Tag) => (
          <div className="tag-card" key={tag.id}>
            <p>{tag.name}</p>
          </div>
        ))}
      </div>
    </>
  );
};
