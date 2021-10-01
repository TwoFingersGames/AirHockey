using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class EffectsLogic : MonoBehaviour
{
    private Volume volume;
    private Bloom bloom;
    private PaniniProjection panini;
    private ChromaticAberration chromatic;
    private FilmGrain film;
    private void Awake()
    {
        volume = Component.FindObjectOfType<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<PaniniProjection>(out panini);
        volume.profile.TryGet<ChromaticAberration>(out chromatic);
        volume.profile.TryGet<FilmGrain>(out film);
    }
    
    public bool GetVolumeActive()
    {
        return volume.enabled;
    }
    public bool GetBloomActive()
    {
        return bloom.active;
    }
    public bool GetCromaticActive()
    {
        return chromatic.active;
    }
    public bool GetPaniniActive()
    {
        return panini.active;
    }
    public bool GetFilmActive()
    {
        return film.active;
    }
    public void SetVolumeActive(bool value)
    {
        volume.enabled = value;
    }
    public void SetBloomActive(bool value)
    {
        bloom.active = value;
    }
    public void SetChromaticActive(bool value)
    {
        chromatic.active = value;
    }
    public void SetPaniniActive(bool value)
    {
        panini.active = value;
    }
    public void SetFilmActive(bool value)
    {
        film.active = value;
    }


}
